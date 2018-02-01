using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Insurance.Data;
using Insurance.Core.CRUD;

namespace Insurance.Controllers
{
    public class ClientPoliciesController : Controller
    {
        private IClientPolicyRepository _clientPolicyRepository;

        public ClientPoliciesController()
        {
            this._clientPolicyRepository = new ClientPolicyRepository(new InsuranceContext());
        }

        // GET: ClientPolicies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPolicy clientPolicy = _clientPolicyRepository.GetClientPolicyById(id.Value);
            if (clientPolicy == null)
            {
                return HttpNotFound();
            }
            return View(clientPolicy);
        }

        // GET: ClientPolicies/Create
        public ActionResult Create()
        {
            using (var context = new ClientRepository(new InsuranceContext()))
            {
                ViewBag.ClientId = new SelectList(context.GetClient(), "Id", "Document");
            }
            using (var context = new PolicyRepository(new InsuranceContext()))
            {
                ViewBag.PolicyId = new SelectList(context.GetPolicy(), "Id", "Name");
            }
            return View();
        }

        // POST: ClientPolicies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientId,PolicyId,StartTime,EndTime")] ClientPolicy clientPolicy)
        {
            if (ModelState.IsValid)
            {
                _clientPolicyRepository.InsertClientPolicy(clientPolicy);
                _clientPolicyRepository.Save();

                // Resultados del create
            }
            using (var context = new ClientRepository(new InsuranceContext()))
            {
                ViewBag.ClientId = new SelectList(context.GetClient(), "Id", "Document");
            }
            using (var context = new PolicyRepository(new InsuranceContext()))
            {
                ViewBag.PolicyId = new SelectList(context.GetPolicy(), "Id", "Name");
            }
            return View(clientPolicy);
        }

        // GET: ClientPolicies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPolicy clientPolicy = _clientPolicyRepository.GetClientPolicyById(id.Value);
            if (clientPolicy == null)
            {
                return HttpNotFound();
            }
            using (var context = new ClientRepository(new InsuranceContext()))
            {
                ViewBag.ClientId = new SelectList(context.GetClient(), "Id", "Document");
            }
            using (var context = new PolicyRepository(new InsuranceContext()))
            {
                ViewBag.PolicyId = new SelectList(context.GetPolicy(), "Id", "Name");
            }
            return View(clientPolicy);
        }

        // POST: ClientPolicies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientId,PolicyId,StartTime,EndTime")] ClientPolicy clientPolicy)
        {
            if (ModelState.IsValid)
            {
                _clientPolicyRepository.UpdateClientPolicy(clientPolicy);
                _clientPolicyRepository.Save();
                //Validar 
            }
            using (var context = new ClientRepository(new InsuranceContext()))
            {
                ViewBag.ClientId = new SelectList(context.GetClient(), "Id", "Document");
            }
            using (var context = new PolicyRepository(new InsuranceContext()))
            {
                ViewBag.PolicyId = new SelectList(context.GetPolicy(), "Id", "Name");
            }
            return View(clientPolicy);
        }

        // GET: ClientPolicies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPolicy clientPolicy = _clientPolicyRepository.GetClientPolicyById(id.Value);
            if (clientPolicy == null)
            {
                return HttpNotFound();
            }
            return View(clientPolicy);
        }

        // POST: ClientPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _clientPolicyRepository.DeleteClientPolicy(id);
            _clientPolicyRepository.Save();
            //Retornar respuesta en ajax
            return RedirectToAction("Index");
        }
    }
}
