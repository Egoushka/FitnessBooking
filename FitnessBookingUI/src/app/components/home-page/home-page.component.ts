import { AuthService } from '../../shared/service/user.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Gym } from 'src/app/model/gym/gym.model';
import { GymService } from 'src/app/shared/service/gym.service';
@Component({
  selector: 'home-page',
  templateUrl: './home-page.component.html',
})
export class HomePageComponent {
  public gyms$: Gym[] = [];
  constructor(
    public authService: AuthService,
    private router: Router,
    private gymService: GymService,
    private route: ActivatedRoute
  ) {}
  ngOnInit() {
    this.gymService.get().subscribe((gyms) => (this.gyms$ = gyms));
  }
  showGym(id: number) {
    sessionStorage.setItem('gymId', id.toString());
    this.router.navigate([`sections`]);
  }
  logOut() {
    sessionStorage.removeItem('gymId');
    this.authService.logOut();
    console.log(localStorage.getItem('access_token'));
    this.router.navigate(['sign-in']);
  }
  newGym(){
    this.router.navigate(['add-edit-gym-page']);
  }
  editGym(id: number, name: string, location: string, description: string){

    sessionStorage.setItem('gymId', id.toString());
    sessionStorage.setItem('name', name);
    sessionStorage.setItem('location', location);
    sessionStorage.setItem('description', description);

    this.router.navigate(['add-edit-gym-page']);
  }
  showCoachPage() {
    this.router.navigate(['coach-home-page']);
  }
  showAdministratorPage() {
    this.router.navigate(['coaches']);
  }
  showVisitorPage() {
    this.router.navigate([`visitor-home-page`]);

  }
}
