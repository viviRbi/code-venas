import { Router } from 'express';
import * as PostControllerMessage from '../controllers/postMessage.controller';
const router = new Router();



//getMessage
router.route('/getMessage/:param').get(PostControllerMessage.getMessage);

//semd message
router.route('/sendMessage/:param').post(PostControllerMessage.sendMessage);

//update message
router.route('/updateMessage/:param').put(PostControllerMessage.updateMessage);

//delete message
router.route('/deleteMessage/:param').delete(PostControllerMessage.deleteMessage);
export default router;
