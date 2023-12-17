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
    [HttpPost]
    [Route("addkey")]
    public async Task AddNewKey(string? key,string? secretKey)
    {

        if (secretKey == await System.IO.File.ReadAllTextAsync("./SecretString.txt"))
        {
         
            _dbContext.Keys.Add(new Key()
                {Id = new Guid().ToString(), isActive = false, KeyProp = Guid.Parse(key).ToString()});
        }
    }
    [HttpGet]
    [Route("activekey")]
    public async Task<IActionResult> ActivateProduct(string? key)
    {
        Key? _key= _dbContext.Keys.FirstOrDefault(k => k.KeyProp == Guid.Parse(key).ToString());
        if (_key == null)
        {
            return Json(false);
        }

        _key.isActive = true;
        return Json(true);
    }
}