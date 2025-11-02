using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Smart_Home_API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
      

        // GET: api/room/all
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = RoomServices.GetAllRooms();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // GET: api/room/get/{id}
        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = RoomServices.GetRoom(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Room not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // POST: api/room/create
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(RoomDTO room)
        {
            if (room == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data");

            var data = RoomServices.Create(room);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // PUT: api/room/update/{id}
        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update(int id, RoomDTO room)
        {
            if (room == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data");

            room.ID = id;
            var data = RoomServices.Update(room);

            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Room not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // DELETE: api/room/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = RoomServices.Delete(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Room not found");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        

        // GET: api/room/devices/{roomId}
        [HttpGet]
        [Route("devices/{roomId}")]
        public HttpResponseMessage GetDevices(int roomId)
        {
            var data = RoomServices.GetDevices(roomId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // PUT: api/room/turnonall/{roomId}
        [HttpPut]
        [Route("turnonall/{roomId}")]
        public HttpResponseMessage TurnOnAll(int roomId)
        {
            var data = RoomServices.TurnOnAll(roomId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // PUT: api/room/turnoffall/{roomId}
        [HttpPut]
        [Route("turnoffall/{roomId}")]
        public HttpResponseMessage TurnOffAll(int roomId)
        {
            var data = RoomServices.TurnOffAll(roomId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // PUT: api/room/turnon/{roomId}/{deviceId}
        [HttpPut]
        [Route("turnon/{roomId}/{deviceId}")]
        public HttpResponseMessage TurnOnDevice(int roomId, int deviceId)
        {
            var data = RoomServices.TurnOnDevice(roomId, deviceId);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Device not found in room");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // PUT: api/room/turnoff/{roomId}/{deviceId}
        [HttpPut]
        [Route("turnoff/{roomId}/{deviceId}")]
        public HttpResponseMessage TurnOffDevice(int roomId, int deviceId)
        {
            var data = RoomServices.TurnOffDevice(roomId, deviceId);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Device not found in room");

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
