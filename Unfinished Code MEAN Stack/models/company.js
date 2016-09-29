import mongoose from 'mongoose';
const Schema = mongoose.Schema;

const companySchema = new Schema({
  cuid: { type: 'String', required:true},
  name: { type: 'String', required: true },
  phone: { type: 'String', required: true},
  email: { type: 'String', required: true},
  website: { type: 'String', required: true},
  type: { type: 'String', required: true},
  dateAdded: { type: 'Date', default: Date.now, required: true }
});

export default mongoose.model('Company', companySchema);