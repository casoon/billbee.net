using Billbee.Net.Endpoints;
using Billbee.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers;

/// <summary>
///     Represents a controller for handling customer addresses.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CustomerAddressController(CustomerAddressEndpoint customerAddressEndpoint) : ControllerBase
{
    /// <summary>
    ///     Adds a new customer address asynchronously.
    /// </summary>
    /// <param name="newAddress">The customer address to add. Must be an instance of CustomerAddress class</param>
    /// <returns>A task representing the asynchronous operation</returns>
    [HttpPost]
    public async Task<IActionResult> AddCustomerAddress([FromBody] CustomerAddress newAddress)
    {
        await customerAddressEndpoint.AddAsync(newAddress);
        return Ok("New customer address added.");
    }

    /// <summary>
    ///     Retrieves a specific customer address by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the customer address.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the requested customer address.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerAddress(long id)
    {
        var address = await customerAddressEndpoint.GetAsync(id);
        if (address != null) return Ok(address);
        return NotFound("Address not found.");
    }
}