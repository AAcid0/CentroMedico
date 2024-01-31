import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { paciente } from '../Interfaces/Paciente';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {
  private endPoint = environment.endPoint;
  private apiUrl = this.endPoint + "CentroMedico"

  constructor(private http:HttpClient) { }

  ListarPacientes():Observable<paciente[]>
  {
    return this.http.get<paciente[]>(`${this.apiUrl}pacientes`);
  }

  ObtenerPaciente(id:number):Observable<paciente>
  {
    return this.http.get<paciente>(`${this.apiUrl}paciente/${id}`);
  }

  CrearPaciente(request:paciente):Observable<paciente>
  {
    return this.http.post<paciente>(`${this.apiUrl}crear`, request);
  }

  ActualizarPaciente(request:paciente):Observable<void>
  {
    return this.http.put<void>(`${this.apiUrl}actualizar`, request);
  }

  EliminarPaciente(id:number):Observable<void>
  {
    return this.http.delete<void>(`${this.apiUrl}eliminar/${id}`);
  }
}
