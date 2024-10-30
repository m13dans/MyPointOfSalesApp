import type { CanActivateFn } from '@angular/router';

export const auhtGuard: CanActivateFn = (route, state) => {
  return true;
};
