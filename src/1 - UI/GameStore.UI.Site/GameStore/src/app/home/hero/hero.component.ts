import { Component, OnInit } from '@angular/core';
import { HeroSlide } from './hero-slide.model';

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
        'background': 'url("{{imagePath}}")'
      }), { params: { imagePath : '' } }),
      state('slide2', style({
        'background': 'url("{{imagePath}}")'
      }), { params: { imagePath : '' } }),
      state('slide3', style({
        'background': 'url("{{imagePath}}")'
      }), { params: { imagePath : '' } }),
      state('slide4', style({
        'background': 'url("{{imagePath}}")'
      }), { params: { imagePath : '' } }),
      transition('slide1 => slide2', animate("500ms ease-in")),
      transition('slide2 => slide3', animate("500ms ease-in")),
      transition('slide3 => slide4', animate("500ms ease-in")),
      transition('slide4 => slide1', animate("500ms ease-in"))
    ])
  ]

})
export class HeroComponent implements OnInit {
  
  slideCounter: number = 0;
  states = ['slide1', 'slide2', 'slide3', 'slide4']
  slides: HeroSlide[] = new Array<HeroSlide>(4)
   
  constructor() {

    //todo: create web service to feed the slides
    this.slides[0] = { gameName: 'Portal', gameDescription: '', imagePath: '../../../assets/images/hero/wall1.jpg' }
    this.slides[1] = { gameName: 'Zelda: Breath of the Wild', gameDescription: '', imagePath: '../../../assets/images/hero/wall2.png' },
    this.slides[2] = { gameName: 'Rise of the Tomb Raider', gameDescription: '', imagePath: '../../../assets/images/hero/wall3.jpg' },
    this.slides[3] = { gameName: 'Fallout 4', gameDescription: '', imagePath: '../../../assets/images/hero/wall4.jpg' }
    this.changeSlide()
  }

  ngOnInit() { }

  changeSlide() {
    setInterval(() => {
      if (this.states[this.slideCounter] != 'slide4')
        this.slideCounter++
      else
        this.slideCounter = 0;
    }, 6000);
  }
}
