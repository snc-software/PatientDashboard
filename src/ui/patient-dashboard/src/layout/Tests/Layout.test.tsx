import { render, screen } from '@testing-library/react';
import Layout from "../Layout";

describe("LayoutTests", () => {

    it('should render the header', () => {
        render( <Layout><p>TestChild</p></Layout>);
        const header = screen.queryByTestId("header");
        expect(header).toBeDefined();
    })

    it('should render the children',  () => {
        render( <Layout><p>TestChild</p></Layout>);
        const children = screen.getByText(/TestChild/i);
        expect(children).toBeInTheDocument();
    });
})