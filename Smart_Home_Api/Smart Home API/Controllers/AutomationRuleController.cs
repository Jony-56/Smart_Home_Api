using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Smart_Home_API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/rule")]
    public class AutomationRuleController : ApiController
    {
        // ---------- CRUD ----------

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = AutomationRuleServices.GetAllRules();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = AutomationRuleServices.GetRule(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Rule not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(AutomationRuleDTO rule)
        {
            if (rule == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data");

            var data = AutomationRuleServices.Create(rule);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update(int id, AutomationRuleDTO rule)
        {
            rule.Id = id;
            var data = AutomationRuleServices.Update(rule);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Rule not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = AutomationRuleServices.Delete(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Rule not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPut]
        [Route("enable/{id}")]
        public HttpResponseMessage Enable(int id)
        {
            var data = AutomationRuleServices.EnableRule(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Rule not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPut]
        [Route("disable/{id}")]
        public HttpResponseMessage Disable(int id)
        {
            var data = AutomationRuleServices.DisableRule(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Rule not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // ---------- Rule Evaluations ----------

        // POST: api/rule/evaluate/temp/32/2
        [HttpPost]
        [Route("evaluate/temp/{temp}/{deviceId}")]
        public HttpResponseMessage EvaluateTemp(double temp, int deviceId)
        {
            var result = AutomationRuleServices.EvaluateTempRule(temp, deviceId);
            return Request.CreateResponse(HttpStatusCode.OK, new { Result = result });
        }

        // POST: api/rule/evaluate/humidity/35/3
        [HttpPost]
        [Route("evaluate/humidity/{humidity}/{deviceId}")]
        public HttpResponseMessage EvaluateHumidity(double humidity, int deviceId)
        {
            var result = AutomationRuleServices.EvaluateHumidityRule(humidity, deviceId);
            return Request.CreateResponse(HttpStatusCode.OK, new { Result = result });
        }

        // POST: api/rule/evaluate/time/4/Fan
        [HttpPost]
        [Route("evaluate/time/{deviceId}/{type}")]
        public HttpResponseMessage EvaluateTime(int deviceId, string type)
        {
            var now = DateTime.Now;
            var result = AutomationRuleServices.EvaluateTimeRule(now, type, deviceId);
            return Request.CreateResponse(HttpStatusCode.OK, new { Result = result, Time = now.ToString("HH:mm") });
        }

    }
}
