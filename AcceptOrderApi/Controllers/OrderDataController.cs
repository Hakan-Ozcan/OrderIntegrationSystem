using BusinessLayer.Abstract;
using BusinessLayer.Orders;
using EntityLayer.Orders;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.RabbitMQ;


namespace AcceptOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDataController : ControllerBase
    {
        private readonly ILogger<OrderDataController> _logger;

        private readonly IOrderDataService _orderDataManager;
        private readonly IConfiguration _configuration;
        private readonly IBusControl _busControl;
        public OrderDataController(IOrderDataService orderDataManager, ILogger<OrderDataController> logger, IConfiguration configuration)
        {
            _orderDataManager = orderDataManager;
            _logger = logger;
            _configuration = configuration;
            // _busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            // {
            //     var host = cfg.Host(new Uri(_configuration.GetSection("RabbitMQ:Host").Value), hst =>
            //     {
            //         hst.Username(_configuration.GetSection("RabbitMQ:UserName").Value);
            //         hst.Password(_configuration.GetSection("RabbitMQ:Password").Value);
            //     });

            //     // Exchange yapılandırması
            //     cfg.ExchangeType = ExchangeType.Direct;
            //     cfg.ReceiveEndpoint(host, _configuration.GetSection("RabbitMQ:QueueName").Value, e =>
            //     {
            //         e.BindMessageExchanges = false;
            //         e.Consumer<SubmitOrderConsumer>(_orderDataManager); // Consumer tanımlaması
            //     });
            // });

            // _busControl.Start();
        }

        [HttpGet]
        public ActionResult<List<OrderData>> Get()
        {
            _logger.LogInformation("Getting order data.");
            return _orderDataManager.GetOrderDatas();
        }
        [HttpGet("{id}")]
        public ActionResult<OrderData> Get(int id)
        {
            if (id < 1)
                return BadRequest();

            if (_orderDataManager.GetOrderData(id) == null)
            {
                _logger.LogWarning("No order data found with ID {OrderId}.", id);
                return NotFound();
            }
               
            else

                try
                {
                    _logger.LogInformation("Retrieving order data with ID {OrderId}.", id);
                    return _orderDataManager.GetOrderData(id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error retrieving order data with ID {OrderId}.", id);
                    return BadRequest(ex.Message);
                }

        }
        [HttpPost]
        public ActionResult<OrderData> Post([FromBody] OrderData product)
        {
            // Aynı müşteri için tekrar eden müşteri sipariş numarası yeniden kabul edilmemelidir.
            if (_orderDataManager.GetOrderDataByCustomerOrderId(product.MusteriSiparisNo) != null)
            {
                _logger.LogWarning("An order data with the same CustomerOrderId already exists.");
                return Conflict("An order data with the same CustomerOrderId already exists.");
            }

            // OrderData objesinin kendisi RabbitMQ mesaj olarak gönderilir.
            var sendEndpoint = _busControl.GetSendEndpoint(new Uri(_configuration.GetSection("RabbitMQ:SendEndpoint").Value)).Result;
            sendEndpoint.Send(product);

            _logger.LogInformation("Submitted order data {@Product}", product);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public ActionResult<List<OrderData>> Put(int id, OrderData product)
        {
            _orderDataManager.OrderDataUpdate(product);
            var updatedData = _orderDataManager.GetOrderDatas();
            _logger.LogInformation("Updated order data with ID {OrderId}.", id);
            return Ok(updatedData);
        }
        [HttpDelete("{id}")]
        public ActionResult<List<OrderData>> Delete(int id)
        {
            _orderDataManager.OrderDataRemove(id);
            _logger.LogInformation("Deleted order data with ID {OrderId}.", id);
            return Ok();
        }


    }
    
}
