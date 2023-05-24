import { TestBed } from '@angular/core/testing';

import { SafetyDiscussionService } from './safety-discussion.service';

describe('SafetyDiscussionService', () => {
  let service: SafetyDiscussionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SafetyDiscussionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
