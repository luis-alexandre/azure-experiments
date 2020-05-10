using AppConfiguration.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace AppConfiguration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AzureAppSettingsController : ControllerBase
    {
        private readonly ILogger<AzureAppSettingsController> _logger;
        private readonly Settings _settings;

        public AzureAppSettingsController(ILogger<AzureAppSettingsController> logger,
                                          IOptionsSnapshot<Settings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var appName = _settings.AppName;
                var version = _settings.Version;

                return Ok(new { AppName = appName, Version = version });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
