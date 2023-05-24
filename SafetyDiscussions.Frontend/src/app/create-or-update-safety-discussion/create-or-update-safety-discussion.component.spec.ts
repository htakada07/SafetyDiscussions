import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateOrUpdateSafetyDiscussionComponent } from './create-or-update-safety-discussion.component';

describe('CreateOrUpdateSafetyDiscussionComponent', () => {
  let component: CreateOrUpdateSafetyDiscussionComponent;
  let fixture: ComponentFixture<CreateOrUpdateSafetyDiscussionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateOrUpdateSafetyDiscussionComponent]
    });
    fixture = TestBed.createComponent(CreateOrUpdateSafetyDiscussionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
