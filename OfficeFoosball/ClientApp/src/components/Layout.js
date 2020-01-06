import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    const isAuth = this.props.isAuth;

    return (
      <div>
        <NavMenu isAuth={isAuth} />
        <Container>{this.props.children}</Container>
      </div>
    );
  }
}
