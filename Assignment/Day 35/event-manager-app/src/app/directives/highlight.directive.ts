import { Directive, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: false
})
export class HighlightDirective implements OnInit {
  @Input('appHighlight') price: number = 0;

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  ngOnInit() {
    if (this.price > 2000) {
      this.renderer.setStyle(this.el.nativeElement, 'background-color', '#FFD700'); // Light Gold
      this.renderer.setStyle(this.el.nativeElement, 'font-weight', 'bold');
    }
  }
}
