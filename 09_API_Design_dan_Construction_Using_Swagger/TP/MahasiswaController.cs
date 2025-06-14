using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tpmodul9_2211104029.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        public class Mahasiswa
        {
            public string Nama { get; set; }
            public string Nim { get; set; }
        }

        private static List<Mahasiswa> listMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Aufa Muhammad", Nim = "2211104020" },
            new Mahasiswa { Nama = "Doanta Aloycius", Nim = "2111104029" },
            new Mahasiswa { Nama = "Lintang Suminar", Nim = "2211104009" },
            new Mahasiswa { Nama = "Rezky Pratiwi", Nim = "2211104029" },
        };

        // GET /api/mahasiswa
        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
        {
            return listMahasiswa;
        }

        // GET /api/mahasiswa/{id}
        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> Get(int id)
        {
            if (id < 0 || id >= listMahasiswa.Count)
                return NotFound();
            return listMahasiswa[id];
        }

        // POST /api/mahasiswa
        [HttpPost]
        public void Post([FromBody] Mahasiswa mhs)
        {
            listMahasiswa.Add(mhs);
        }

        // DELETE /api/mahasiswa/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id >= 0 && id < listMahasiswa.Count)
            {
                listMahasiswa.RemoveAt(id);
            }
        }
    }
}
