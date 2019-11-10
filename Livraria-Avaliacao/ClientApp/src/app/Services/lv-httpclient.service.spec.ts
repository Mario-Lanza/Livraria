import { TestBed } from '@angular/core/testing';

import { LvHttpclientService } from './lv-httpclient.service';

describe('LvHttpclientService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LvHttpclientService = TestBed.get(LvHttpclientService);
    expect(service).toBeTruthy();
  });
});
