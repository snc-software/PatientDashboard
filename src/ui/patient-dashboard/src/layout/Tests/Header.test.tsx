import { render, screen } from '@testing-library/react';
import Header from "../Header";

describe("HeaderTests", () => {

    it('should render an app bar in the primary colour',  () => {
        render( <Header />);
        const appBarElement = screen.getByRole('banner')
        expect(appBarElement).toBeInTheDocument();
        expect(appBarElement).toHaveClass("MuiAppBar-colorPrimary");
    });

    it('should render the app name',  () => {
        render( <Header />);
        const typography = screen.getByRole('heading', { name: /Patient Dashboard/i })
        expect(typography).toBeInTheDocument();
    });

})