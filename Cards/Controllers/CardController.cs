using Microsoft.AspNetCore.Mvc;

namespace Cards.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{

    private readonly ILogger<CardController> _logger;

    public CardController(ILogger<CardController> logger)
    {
        _logger = logger;
    }    
}
