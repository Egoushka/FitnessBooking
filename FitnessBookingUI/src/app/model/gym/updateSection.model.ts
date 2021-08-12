import { Section } from './../section/section.model';
export class UpdateGym {
  id: number;
  name: string;
  location: string;
  description: string;

  constructor(
    id: number,
    name: string,
    location: string,
    description: string,
  ) {
    this.id = id;
    this.name = name;
    this.location = location;
    this.description = description;
  }
}
