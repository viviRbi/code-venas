import { Router } from 'express';
import * as CompanyController from '../controllers/company.controller';
const router = new Router();

// Get all Companies
router.route('/getCompanies').get(CompanyController.getCompanies);

// Get one company by id
router.route('/getCompany/:id').get(CompanyController.getCompany);

// Add a new company
router.route('/addCompany').post(CompanyController.addCompany);
// Update company fields
router.route('/updateCompany').put(CompanyController.updateCompany);
// Delete a company by id
router.route('/deleteCompany/:id').delete(CompanyController.deleteCompany);

export default router;
