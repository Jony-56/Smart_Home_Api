using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Smart_Home_API.Controllers
{
    [RoutePrefix("api/energylog")]
    [EnableCors("*", "*", "*")]
    public class EnergyLogController : ApiController
    {
        

        // GET: api/energylog/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = EnergyLogServices.GetAllLogs();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // GET: api/energylog/{id}
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = EnergyLogServices.GetLog(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Energy log not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // POST: api/energylog/create
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(EnergyLogDTO log)
        {
            if (log == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data");

            var data = EnergyLogServices.Create(log);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // PUT: api/energylog/update/{id}
        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update(int id, EnergyLogDTO log)
        {
            log.Id = id;
            var data = EnergyLogServices.Update(log);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Energy log not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // DELETE: api/energylog/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = EnergyLogServices.Delete(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Energy log not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

       

        // GET: api/energylog/device/{deviceId}?start=2025-01-01&end=2025-02-01
        [HttpGet]
        [Route("device/{deviceId}")]
        public HttpResponseMessage GetTotalByDevice(int deviceId, DateTime start, DateTime end)
        {
            var total = EnergyLogServices.GetTotalByDevice(deviceId, start, end);
            return Request.CreateResponse(HttpStatusCode.OK, new { DeviceId = deviceId, TotalUsageKWh = total });
        }

        // GET: api/energylog/room/{roomId}?start=2025-01-01&end=2025-02-01
        [HttpGet]
        [Route("room/{roomId}")]
        public HttpResponseMessage GetTotalByRoom(int roomId, DateTime start, DateTime end)
        {
            var total = EnergyLogServices.GetTotalByRoom(roomId, start, end);
            return Request.CreateResponse(HttpStatusCode.OK, new { RoomId = roomId, TotalUsageKWh = total });
        }

       
    }
}
