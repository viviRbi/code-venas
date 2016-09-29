import mongoose from 'mongoose';
const Schema = mongoose.Schema;

const messageSchema = new Schema({
  message: { type: 'String', required: true },
  dateAdded: { type: 'Date', default: Date.now, required: true }
});

export default mongoose.model('Message', messageSchema);