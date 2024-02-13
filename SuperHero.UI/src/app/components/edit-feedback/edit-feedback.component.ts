import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { Feedback } from 'src/app/models/feedback';
import { ChatGPTResponse } from 'src/app/models/response';
import { FeedbackService } from 'src/app/services/feedback.service';
import { ResponseService } from 'src/app/services/response.service';

@Component({
  selector: 'app-edit-feedback',
  templateUrl: './edit-feedback.component.html',
  styleUrls: ['./edit-feedback.component.css']
})
export class EditFeedbackComponent implements OnInit {

  @Input() feedback?: Feedback;
  @Output() feedbacksUpdated = new EventEmitter<Feedback[]>();
  @Output() responsesUpdated = new EventEmitter<ChatGPTResponse[]>();

  constructor(private feedbackService: FeedbackService, private responseService: ResponseService) { }

  ngOnInit(): void {
  }
  
  updateFeedback(feedback: Feedback) {
    this.feedbackService
      .updateFeedback(feedback)
      .subscribe((feedbacks: Feedback[]) => this.feedbacksUpdated.emit(feedbacks));
  }

  deleteFeedback(feedback: Feedback) {
    this.feedbackService
      .deleteFeedback(feedback)
      .subscribe((feedbacks: Feedback[]) => this.feedbacksUpdated.emit(feedbacks));
  }

  createFeedback(feedback: Feedback) {
    this.feedbackService
      .createFeedback(feedback)
      .subscribe((feedbacks: Feedback[]) => this.feedbacksUpdated.emit(feedbacks));
  }
}
