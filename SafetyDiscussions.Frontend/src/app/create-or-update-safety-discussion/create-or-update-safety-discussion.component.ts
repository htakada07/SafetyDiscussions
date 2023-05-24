import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { SafetyDiscussions } from 'src/contracts/safety-discussions';
import { SafetyDiscussionService } from 'src/services/safety-discussion.service';
import { SuccessModalComponent } from '../success-modal-component/success-modal-component';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-create-or-update-safety-discussion',
  templateUrl: './create-or-update-safety-discussion.component.html',
  styleUrls: ['./create-or-update-safety-discussion.component.css']
})
export class CreateOrUpdateSafetyDiscussionComponent {
  title = "Safety Discussions";
  safetyDiscussion: SafetyDiscussions = {
      id: 0,
      observer: '',
      dateOfDiscussion: new Date(),
      locationOfDiscussion: '',
      colleague: '',
      subjectOfDiscussion: '',
      outcomes: ''
  };
  maxDate: Date;

  constructor(
    private safetyDiscussionService: SafetyDiscussionService,
    private router: Router,
    private dialog: MatDialog,
    private route: ActivatedRoute)
  { 
    // Used to max limit of datepicker to today's date only
    this.maxDate = new Date();
  }

  ngOnInit(){
    // Check the id if the user is trying to update instead of create
    this.route.params.subscribe(params => {
      const id = params['id']; // Retrieve the id value from the URL
      this.safetyDiscussionService.getById(id).subscribe({
        next: (value) => {
          this.safetyDiscussion = value;
        },
        error: (error) => {
          // if the id is non existent, redirect to create
          this.router.navigate(['/create']);
        }
      })
    });
  }

  cancel() {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '250px',
      data: 'Are you sure you want to cancel?'
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.navigateToHome()
      }
    });
  }

  submit() {
    this.safetyDiscussionService.create(this.safetyDiscussion).subscribe({
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        const dialogRef: MatDialogRef<SuccessModalComponent> = this.dialog.open(SuccessModalComponent, {
          width: '300px', // Customize the width as per your requirements
        });

        dialogRef.afterClosed().subscribe(() => {
          this.navigateToHome()
        });
      }
    });
  }

  navigateToHome(){
    this.router.navigate(['/']);
  }
}
