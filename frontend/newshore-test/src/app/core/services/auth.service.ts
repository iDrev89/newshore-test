import { AuthToken, UserDetail, UserData } from '@core/models/auth.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { CONSTANTS } from './constants';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private _http: HttpClient, private router: Router) {}

  login(userdetails: UserDetail) {
    const body = { email: userdetails.username, password: userdetails.password };

    this._http.post<UserData>('/Login', body).subscribe((response) => {
      this.setUserPayload(response);
      this.router.navigate(['after-login']);
    });
  }

  logout() {
    const body = new HttpParams().set(CONSTANTS.REFRESH_TOKEN, this.getRefreshToken()!);
    this._http.post('<logout_URL>', body.toString(), { headers: this.headers }).subscribe({
      next: () => window.location.reload(),
      complete: () => {
        localStorage.clear();
      },
      error: () => {
        localStorage.clear();
        window.location.reload();
      },
    });
  }

  setUserPayload(payload: UserData) {
    localStorage.setItem('user', JSON.stringify(payload));
  }

  getUserPayload() {
    return localStorage.getItem('user');
  }
  isLoggedIn() {
    return this.getUserPayload() ? true : false;
  }

  storeToken(token: AuthToken) {
    localStorage.setItem('token', token.access_token);
    localStorage.setItem(CONSTANTS.REFRESH_TOKEN, token.refresh_token);
  }

  getToken() {
    return JSON.parse(localStorage.getItem('user')!).token;
  }

  refreshToken() {
    const body = new HttpParams().set(CONSTANTS.REFRESH_TOKEN, this.getRefreshToken()!);
    return this._http.post<AuthToken>('<refresh_token_url>', body.toString(), {
      headers: this.headers,
    });
  }

  getRefreshToken() {
    return localStorage.getItem(CONSTANTS.REFRESH_TOKEN);
  }
}
