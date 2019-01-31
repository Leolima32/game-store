import { Component, OnInit } from '@angular/core';
import { GenresService } from './genres.service';
import { Genre } from './genre.model';

@Component({
  selector: 'gs-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  genresList: Genre[]
  constructor(private service: GenresService) { }

  ngOnInit() {
    this.service.getAllGenres()
      .subscribe(genres => this.genresList = genres);
    
  }

}
