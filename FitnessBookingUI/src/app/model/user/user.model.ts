export class User {
  constructor(id: number, roleId: number, email: string, name: string) {
    this.id = id;
    this.email = email;
    this.name = name;
    this.roleId =roleId;
  }
  id: number;
  roleId: number;
  email: string;
  name: string;
}
