import Message from '../models/message';
import cuid from 'cuid';
import slug from 'slug';
import sanitizeHtml from 'sanitize-html';

export function getMessage(req,res){
  //res.send({message:'Get Message'});
  Message.findOne({message:req.params.param}).exec((err,msg) =>{
    if (err) {
      return res.status(500).send(err);
    }
    res.json({message:msg});
  });
}

export function sendMessage(req,res){
  const newMessage = new Message(req.params);
  //set schema
  newMessage.message = req.params.param;
  newMessage.save((err, saved) => {
    if (err) {
      return res.status(500).send(err);
    }
    return res.json({ message: saved });
  });
}

export function updateMessage(req,res){
  res.send({message: 'Update Your Message:'+req.params.param});
}

export function deleteMessage(req,res){
  res.send({message: 'Message Deleted:'+req.params.param});
}