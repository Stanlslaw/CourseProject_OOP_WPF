using System.Net.Mime;
using KeyServer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PDDTestBelarus.Models;

namespace KeyServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeyController:Controller
{
    private Models.AppContext _dbContext;

    
    public KeyController( Models.AppContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [Route("activekey")]
    public async Task<string> ActivateProduct(string? key,string? uuid)
    {
        AuthorizeData data;
        Key? _key= _dbContext.Keys.FirstOrDefault(k => k.KeyProp == Guid.Parse(key).ToString());
        if (_key == null||_key.IsActive==1)
        {
            data = new AuthorizeData();
            data.uuid = uuid;
            data.hash = null;
            return JsonConvert.SerializeObject(data);
        }

        _key.AppUuid = uuid;
        string hash=MD5Hash.ComputeMD5Hash(uuid, "secret");
        _key.Hash = hash;
        _key.IsActive = 1;
        await _dbContext.SaveChangesAsync();
        data = new AuthorizeData();
        data.uuid = uuid;
        data.hash = hash;
        
        return JsonConvert.SerializeObject(data);
    }
}