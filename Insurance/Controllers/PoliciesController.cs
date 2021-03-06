﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Insurance.Data;
using Insurance.Core.CRUD;
using Insurance.Core.Services;

namespace Insurance.Controllers
{
    [Authorize]
    public class PoliciesController : Controller
    {
        private IPolicyRepository _policyRepository;

        public PoliciesController()
        {
            this._policyRepository = new PolicyRepository();
        }

        // GET: Policies
        public ActionResult Index()
        {
            var policies = _policyRepository.GetPolicy();
            return View(policies);
        }

        // GET: Policies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = _policyRepository.GetPolicyById(id.Value);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // GET: Policies/Create
        public ActionResult Create()
        {
            ViewBag.CoverageKindId = new SelectList(_policyRepository.GetCoverageKind(), "Id", "Name");
            ViewBag.RiskKind = new SelectList(_policyRepository.GetRiskKind(), "Id", "Name");
            return View();
        }

        // POST: Policies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Coverage,CoverageKindId,Prize,Period,RiskKind,Description")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                //validar la regla de negocio
                var service = new Service();
                var validate = service.CheckRiskKind(policy.RiskKind, policy.Coverage);
                if (!validate)
                {
                    ModelState.AddModelError("Riesgo alto", "Para el riesgo Alto, la cobertura debe ser menor al 50%");
                    ViewBag.CoverageKindId = new SelectList(_policyRepository.GetCoverageKind(), "Id", "Name", policy.CoverageKindId);
                    ViewBag.RiskKind = new SelectList(_policyRepository.GetRiskKind(), "Id", "Name", policy.RiskKind1);
                    return View(policy);
                }
                _policyRepository.InsertPolicy(policy);
                _policyRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CoverageKindId = new SelectList(_policyRepository.GetCoverageKind(), "Id", "Name", policy.CoverageKindId);
            ViewBag.RiskKind = new SelectList(_policyRepository.GetRiskKind(), "Id", "Name", policy.RiskKind1);
            return View(policy);
        }

        // GET: Policies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = _policyRepository.GetPolicyById(id.Value);
            if (policy == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoverageKindId = new SelectList(_policyRepository.GetCoverageKind(), "Id", "Name", policy.CoverageKindId);
            ViewBag.RiskKind = new SelectList(_policyRepository.GetRiskKind(), "Id", "Name",policy.RiskKind1);
            return View(policy);
        }

        // POST: Policies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Coverage,CoverageKindId,Prize,Period,RiskKind,Description")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                _policyRepository.UpdatePolicy(policy);
                _policyRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CoverageKindId = new SelectList(_policyRepository.GetCoverageKind(), "Id", "Name", policy.CoverageKindId);
            ViewBag.RiskKind = new SelectList(_policyRepository.GetRiskKind(), "Id", "Name", policy.RiskKind1);
            return View(policy);
        }

        // GET: Policies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = _policyRepository.GetPolicyById(id.Value);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Policy policy = _policyRepository.GetPolicyById(id);
            _policyRepository.DeletePolicy(id);
            _policyRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
