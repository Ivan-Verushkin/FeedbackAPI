import { ChatGPTResponse } from "./response";

export class Feedback {
    id?: number;
    feedbackMessage = "";
    created = new Date();
}