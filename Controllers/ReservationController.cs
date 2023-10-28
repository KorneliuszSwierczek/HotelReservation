using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private static List<Reservation> reservations = new List<Reservation>();

        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> Get()
        {
            return Ok(reservations);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Reservation reservation)
        {
            reservation.Id = Guid.NewGuid().GetHashCode();
            reservations.Add(reservation);
            return CreatedAtAction(nameof(Get), new { id = reservation.Id }, reservation);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var reservation = reservations.Find(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservations.Remove(reservation);
            return NoContent();
        }
    }
}
