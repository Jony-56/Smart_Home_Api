using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Smart_Home_API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/device")]
    public class DeviceController : ApiController
    {
        // GET: api/device/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = DeviceServices.GetAllDevices();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // GET: api/device/{id}
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = DeviceServices.GetDevice(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Device not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // POST: api/device/create
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(DeviceDTO device)
        {
            if (device == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data");

            var data = DeviceServices.Create(device);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        // PUT: api/device/update/{id}
        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update(int id, DeviceDTO device)
        {
            if (device == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data");

            device.Id = id;
            var data = DeviceServices.Update(device);

            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Device not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // DELETE: api/device/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = DeviceServices.Delete(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Device not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //Smart Home 

        // PUT: api/device/turnon/{id}
        [HttpPut]
        [Route("turnon/{id}")]
        public HttpResponseMessage TurnOn(int id)
        {
            var data = DeviceServices.TurnOn(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Device not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // PUT: api/device/turnoff/{id}
        [HttpPut]
        [Route("turnoff/{id}")]
        public HttpResponseMessage TurnOff(int id)
        {
            var data = DeviceServices.TurnOff(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Device not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // PUT: api/device/toggle/{id}
        [HttpPut]
        [Route("toggle/{id}")]
        public HttpResponseMessage Toggle(int id)
        {
            var data = DeviceServices.Toggle(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Device not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
