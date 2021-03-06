﻿using Microsoft.AspNetCore.Mvc;
using SocialEvolutionDataCollector.Services;
using SocialEvolutionSensor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SocialEvolutionDataCollector.Controllers
{
    [Route("api/DataCollector")]
    [ApiController]
    public class DataCollectorController : ControllerBase
    {

        private IDataCollectorService<Call> _callCollectorService;
        private IDataCollectorService<Message> _messageCollectorService;

        public DataCollectorController(
            IDataCollectorService<Call> callCollectorService,
            IDataCollectorService<Message> messageCollectorService)
        {
            _callCollectorService = callCollectorService;
            _messageCollectorService = messageCollectorService;
        }

        [Route("latest-calls")]
        [HttpGet]
        public ActionResult<List<Call>> GetLatestCalls()
        {
            var res = _callCollectorService.GetLatestDataAsync();
            return res.Result;
        }


        [Route("latest-messages")]
        [HttpGet]
        public ActionResult<List<Message>> GetLatestMessages()
        {
            var res = _messageCollectorService.GetLatestDataAsync();
            return res.Result;
        }


        [Route("calls")]
        [HttpGet]
        public ActionResult<List<Call>> GetCalls()
        {
            var res = _callCollectorService.GetDataAsync();
            return res.Result;
        }

        [Route("messages")]
        [HttpGet]
        public ActionResult<List<Message>> GetMessages()
        {
            var res = _messageCollectorService.GetDataAsync();
            return res.Result;
        }
    }
}
