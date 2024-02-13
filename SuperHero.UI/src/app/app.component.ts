import { Component, OnChanges, SimpleChanges } from '@angular/core';
import { FeedbackService } from './services/feedback.service';
import { Feedback } from './models/feedback';
import { ResponseService } from './services/response.service';
import { ChatGPTResponse } from './models/response';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'FeedbackApp.UI';
  feedbackToEdit?: Feedback;
  feedbacks: Feedback[] = [];

  responses: ChatGPTResponse[] = [];

  constructor(private feedbackService: FeedbackService, private responseService: ResponseService) {}
  

  ngOnInit(): void {
    this.feedbackService
      .getFeedbacks()
      .subscribe((result: Feedback[]) => (this.feedbacks = result));
    this.responseService
      .getResponses()
      .subscribe((result: ChatGPTResponse[]) => (this.responses = result));
  }


  updatedFeedbacks(feedbacks: Feedback[]){
    this.feedbacks = feedbacks;
  }

  updatedResponses(responses: ChatGPTResponse[]){
    this.responses = responses;
  }

  initNewFeedback() {
    this.feedbackToEdit = new Feedback();
  }

  editFeedback(feedback: Feedback) {
    this.feedbackToEdit = feedback;
  }
}
