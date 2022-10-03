import React from 'react';
import {
  Route,
  Navigate,
  Routes
} from 'react-router-dom';


function PrivateRoute({ component: Component, canActivate, ...rest }) {
  return (
    <Routes>
      <Route
        {...rest}
        render={props =>
          canActivate() ? (
            <Component {...props} />
          ) : (
            <Navigate
              to={{
                pathname: '/login',
                state: { from: props.location }
              }}
            />
          )
        }
      />
    </Routes>
  );
}

export default PrivateRoute;