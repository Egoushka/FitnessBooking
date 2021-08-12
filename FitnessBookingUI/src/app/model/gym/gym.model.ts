import { Section } from '../section/section.model';

export class Gym {
  public id: number;
  public name: string;
  public location: string;
  public description: string;

  constructor(
    id: number,
    name: string,
    location: string,
    description: string,
    sections: Section[]
  ) {
    this.id = id;
    this.name = name;
    this.location = location;
    this.description = description;
    this.sections = sections;
  }
  public sections: Section[] = [];
}
