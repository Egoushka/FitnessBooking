export class UserRegisterModel {
  constructor(
    email: string,
    username: string,
    password: string,
    repeatPassword: string,
    roleId: number
  ) {
    this.email = email;
    this.name = username;
    this.password = password;
    this.repeatPassword = repeatPassword;
    this.roleId = roleId;
  }
  email: string;
  name: string;
  password: string;
  repeatPassword: string;
  roleId: number;
}
