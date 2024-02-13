import { Feedback } from "./feedback";

export class ChatGPTResponse {
    id?: number;
    responseMessage = "";
    feedback: Feedback = new Feedback();
}