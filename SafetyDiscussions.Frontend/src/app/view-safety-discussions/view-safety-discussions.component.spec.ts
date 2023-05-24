import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSafetyDiscussionsComponent } from './view-safety-discussions.component';

describe('ViewSafetyDiscussionsComponent', () => {
  let component: ViewSafetyDiscussionsComponent;
  let fixture: ComponentFixture<ViewSafetyDiscussionsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewSafetyDiscussionsComponent]
    });
    fixture = TestBed.createComponent(ViewSafetyDiscussionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
