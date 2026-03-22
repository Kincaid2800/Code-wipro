import { Component } from '@angular/core';
import { trigger, transition, style, animate } from '@angular/animations';
import { Event } from '../../models/event.model';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrl: './event-list.component.css',
  standalone: false,
  animations: [
    trigger('fadeIn', [
      transition(':enter', [
        style({ opacity: 0, transform: 'translateY(20px)' }),
        animate('600ms ease-out', style({ opacity: 1, transform: 'translateY(0)' }))
      ])
    ])
  ]
})
export class EventListComponent {
  events: Event[] = [
    { name: 'Tech Innovators Conference', date: '2025-09-12', price: 3500, category: 'Conference' },
    { name: 'Creative Writing Workshop', date: '2025-10-05', price: 800, category: 'Workshop' },
    { name: 'Rock Music Concert', date: '2025-11-20', price: 2500, category: 'Concert' },
    { name: 'AI & Machine Learning Summit', date: '2025-12-02', price: 5000, category: 'Conference' }
  ];
}
