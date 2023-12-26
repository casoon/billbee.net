using Billbee.Net.Endpoints;
using Billbee.Net.Enums;
using Billbee.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers;


[ApiController]
[Produces("application/json")]
[Route("api/orders/")]
public class BillbeeController : ControllerBase
{
    private readonly IOrderEndpoint _orders;
    
    public BillbeeController(IOrderEndpoint orders)
    {
        _orders = orders;
    }


    /// <summary>
    /// Action to get a list of all orders in the database.
    /// </summary>
    /// <returns>Returns a list of all orders since yesterday in the database</returns>
    /// /// <response code="200">Returns a list of all orders in the database</response>
    /// /// <response code="400">Returned if the orders couldn't be loaded</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("orders")]
    public ActionResult<List<Order>> Orders()
    {
        try
        {
            return new List<Order>();
            //return _orders.GetAllAsync(minOrderDate: DateTime.Today.AddDays(-1)).GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
