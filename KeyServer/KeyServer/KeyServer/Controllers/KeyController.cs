using System.Net.Mime;
using KeyServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeyServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeyController:Controller
{
    private ApplicationDbContext _dbContext;

    
    public KeyController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [Route("activekey")]
    public async Task<IActionResult> ActivateProduct(string? key,string? uuid)
    {
        Key? _key= _dbContext.Keys.FirstOrDefault(k => k.KeyProp == Guid.Parse(key).ToString());
        if (_key == null||_key.isActive==true)
        {
            return Json(null);
        }

        _key.isActive = true;
        
        return Json(true);
    }
}