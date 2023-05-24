import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { SafetyDiscussions } from 'src/contracts/safety-discussions';
import { SafetyDiscussionService } from 'src/services/safety-discussion.service';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-view-safety-discussions',
  templateUrl: './view-safety-discussions.component.html',
  styleUrls: ['./view-safety-discussions.component.css']
})

export class ViewSafetyDiscussionsComponent implements AfterViewInit {
  displayedColumns: string[] = ['id', 'observer' , 'subjectOfDiscussion', 'locationOfDiscussion', 'dateOfDiscussion', 'colleague', 'actions'];
  dataSource: MatTableDataSource<SafetyDiscussions>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  title = 'View Safety Discussions';
  safetyDiscussions: SafetyDiscussions[] = [];

  constructor(
    private safetyDiscussionService: SafetyDiscussionService,
    private dialog: MatDialog) 
  {
    this.paginator = {} as MatPaginator;
    this.sort = {} as MatSort;

    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource(this.safetyDiscussions);
  }

  ngOnInit() {
    this.getAllSafetyDiscussions();
  }
  
  getAllSafetyDiscussions() {
    this.safetyDiscussionService.getAll().subscribe({
      next: (data) => {
        // Handle the received data
        this.safetyDiscussions = data;
        this.dataSource = new MatTableDataSource(this.safetyDiscussions);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (error) => {
        // Handle the error
        console.error(error);
      },
      complete: () => {
        // Handle the completion
        console.log('Completed');
      }
    });
  }
  
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deleteRow(id: number): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '250px',
      data: 'Are you sure you want to delete this item?'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Delete the item
        this.safetyDiscussionService.delete(id).subscribe({
          error: (error) => {
            // Handle the error
            console.error(error);
          },
          complete: () => {
            this.getAllSafetyDiscussions();
          }
        });
      }
    });
  }
}


