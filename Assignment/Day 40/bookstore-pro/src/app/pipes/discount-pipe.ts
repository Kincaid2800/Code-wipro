import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'discount',
  standalone: false
})
export class DiscountPipe implements PipeTransform {
  transform(value: number, percentage: number = 0): number {
    if (!value || isNaN(value)) return 0;
    const discountAmount = (value * percentage) / 100;
    return value - discountAmount;
  }
}
