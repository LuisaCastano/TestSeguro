using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Insurance.Data;
using Insurance.Core.CRUD;

namespace Insurance.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private IClientRepository _clientRepository;

        public ClientsController()
        {
            this._clientRepository = new ClientRepository();
        }

        // GET: Clients
        public ActionResult Index()
        {
            var model = _clientRepository.GetClient();
            return View(model);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _clientRepository.GetClientById(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Document,FirstName,LastName,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientRepository.InsertClient(client);
                _clientRepository.Save();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _clientRepository.GetClientById(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Document,FirstName,LastName,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientRepository.UpdateClient(client);
                _clientRepository.Save();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _clientRepository.GetClientById(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _clientRepository.DeleteClient(id);
            _clientRepository.Save();
            return RedirectToAction("Index");
        }
        
    }
}
