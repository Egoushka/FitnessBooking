import { SectionRequest } from './section.request';
import { GymRequest } from './gym,request';
export class SearchRequest{
  gymRequest: GymRequest;
  sectionRequest: SectionRequest;

  constructor(gymRequest: GymRequest, sectionRequest: SectionRequest) {
    this.gymRequest = gymRequest
    this.sectionRequest = sectionRequest
  }

}
