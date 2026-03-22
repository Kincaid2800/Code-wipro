import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  console.log('[INTERCEPTOR] Adding dummy token to request:', req.url);
  const authReq = req.clone({
    setHeaders: {
      Authorization: 'Bearer dummy-token'
    }
  });
  return next(authReq);
};
