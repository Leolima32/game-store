import { Component, OnInit } from '@angular/core';

import {
  animate,
  style,
  trigger,
  state,
  transition
} from '@angular/animations';

@Component({
  selector: 'gs-hero',
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.css'],
  animations: [
    trigger('carousel', [
      state('slide1', style({
        'background': 'url(../../../assets/images/hero/wall1.jpg)'
      })),
      state('slide2', style({
        'background': 'url(../../../assets/images/hero/wall2.png)'
      })),
      state('slide3', style({
        'background': 'url(../../../assets/images/hero/wall3.jpg)'
      })),
      state('slide4', style({
        'background': 'url(../../../assets/images/hero/wall4.jpg)'
      })),
      transition('slide1 => slide2', animate("500ms ease-in")),
      transition('slide2 => slide3', animate("500ms ease-in")),
      transition('slide3 => slide4', animate("500ms ease-in")),
      transition('slide4 => slide1', animate("500ms ease-in"))
    ])
  ]
  
})
export class HeroComponent implements OnInit {

  slide = 'slide1';
  slides = ['slide1','slide2','slide3','slide4']
  constructor() { 
    this.changeSlide()
  }

  ngOnInit() { }

  changeSlide() {
    setInterval(() => {
      if(this.slide != 'slide4')
        this.slide = this.slides[this.slides.indexOf(this.slide) + 1]
      else
        this.slide = 'slide1'
    }, 4000);
  }
}
