using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TopTen.Api.Data;
using TopTen.Api.Models;

namespace TopTen.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordCounterController : ControllerBase
    {
        private readonly ILogger<WordCounterController> _logger;
        private readonly IDataManager _dataManager;

        public WordCounterController(ILogger<WordCounterController> logger, IDataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
        }

        [HttpGet]
        public IEnumerable<WordItem> Get()
        {
                var path = "https://archive.org/stream/LordOfTheRingsApocalypticProphecies/Lord%20of%20the%20Rings%20Apocalyptic%20Prophecies_djvu.txt";
                var delim = " ";
                return _dataManager.GetListOfMatchingWords(path, delim);
        }
    }
}
