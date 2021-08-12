import { SectionRequest } from './section.request';

export class GymRequest {
  location: string;
  name: string;

  constructor(location: string, name: string) {
    this.location = location;
    this.name = name;
  }
}
