export class UserRequest{
  id: number;
  roleId: number;
  name: string;
  email: string;

  constructor(
    id: number,
    roleId: number,
    name: string,
    email: string
) {
    this.id = id
    this.roleId = roleId
    this.name = name
    this.email = email
  }

}
